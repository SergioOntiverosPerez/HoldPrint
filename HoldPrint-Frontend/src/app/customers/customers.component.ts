import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Customer } from '../models/Customer';
import { CustomerService } from './Customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  
  public titleCustomers = 'Customers';
  public customerForm: FormGroup;
  public customerSelected: Customer;
  public modalRef: BsModalRef;
  public mode = 'post';
  public customers: Customer[];
  
  constructor(private fb: FormBuilder, private modalService: BsModalService, private customerService: CustomerService) { 
    this.createForm();
  }

  ngOnInit() {
    this.loadCustomers();
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  loadCustomers(){
    this.customerService.getAll().subscribe(
      (customers: Customer[]) => {
        this.customers = customers;
      },
      (error: any) => {
        console.error(error);
      }
    )
  }

  createForm(){
    this.customerForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      cpf: ['', Validators.required]
    }
    );
  }

  saveCustomer(customer: Customer){
    (customer.id === 0)? this.mode = 'post' : this.mode = 'put';
    console.log(customer.id);
    this.customerService[this.mode](customer).subscribe(
      (customer: Customer) => {
        console.log(customer)
        this.loadCustomers()
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  customerSubmit(){
    this.saveCustomer(this.customerForm.value);
  }

  selectCustomer(customer: Customer){
    this.customerSelected = customer;
    this.customerForm.patchValue(customer);
  }

  newCustomer(){
    this.customerSelected = new Customer();
    this.customerForm.patchValue(this.customerSelected);
  }

  back(){
    this.customerSelected = null;
  }

  deleteCustomer(id: number){
    this.customerService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.loadCustomers();
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
  
}
