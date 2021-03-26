import { Component, OnInit, AfterViewInit } from '@angular/core';
import { WebapiService } from 'src/app/webapi.service';
import { Router } from '@angular/router';
import{Branch} from '../../branch.model'
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit,AfterViewInit{

 
  ngAfterViewInit(): void {
   
  }
 
  constructor(private service:WebapiService,private router:Router,private formbuilder:FormBuilder) { }
 
  branch=new Branch();
  branchArray=[] as  any;

  isEdit=false;
  companyobj={
    "email":"",
   "name":"", 
  "totalEmployee":"",
  "address":"",
  "isCompanyActive":"",
  "totalBranch":"",
     "companyBranch":[]

  }


  companydata:any;
  ngOnInit(){
    this.branch=new Branch();
    this.branchArray.push(this.branch)
    this.getLatestDetails()
    this.service.currentMsg.subscribe(data=>{
      
      this.companyobj=data;
      this.isEdit=true;
    })


  }

  AddCompany(formobj: any)
  {
    console.log(this.branchArray);
    debugger;
    const data={
                        
                      "email":formobj.email,
                      "name":formobj.name, 
                      "totalEmployee":formobj.totalEmployee,
                      "address":formobj.address,
                      "isCompanyActive":formobj.isCompanyActive,
                      "totalBranch":this.branchArray.length,
                      "companyBranch":this.branchArray
         }
    this.service.createCompany(data).subscribe(res=>{
      alert("Added Successfully.")
      setTimeout(() => {
        this.router.navigate(['/index']).then(() => {
          window.location.reload();
        });
      }, 1000);
      this.getLatestDetails();
    })
  }

  removeBranch(index:number){
    this.branchArray.splice(index,index);
  }
  getLatestDetails(){
    this.service.getAllCompany().subscribe(res=>{
      this.companydata=res;

      console.log(res)
  });
  
}


AddMore()
{
  this.branch=new Branch();
  this.branchArray.push(this.branch);
}

}
