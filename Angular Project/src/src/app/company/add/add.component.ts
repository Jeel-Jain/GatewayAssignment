import { Component, OnInit, AfterViewInit } from '@angular/core';
import { WebapiService } from 'src/app/webapi.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit,AfterViewInit{
 
  ngAfterViewInit(): void {
   
  }

  constructor(private service:WebapiService,private router:Router) { }

 

  isEdit=false;
  companyobj={
    "email":"",
   "name":"", 
  "totalEmployee":"",
  "address":"",
  "isCompanyActive":"",
  "totalBranch":"",
     "companyBranch":[{
     "branchId":"0",
     "branchName":"0",
     "address":"NA"
     }]

  }
  companydata:any;
  ngOnInit(): void {
   
    this.getLatestDetails()
    this.service.currentMsg.subscribe(data=>{
      
      this.companyobj=data;
      this.isEdit=true;
    })

  }
  AddCompany(formobj: any)
  {
    debugger;
    const data={
                        
                      "email":formobj.email,
                      "name":formobj.name, 
                      "totalEmployee":formobj.totalEmployee,
                      "address":formobj.address,
                      "isCompanyActive":true,
                      "totalBranch":formobj.totalBranch,
                      "companyBranch":[{
                                      "branchId":formobj.branchId,
                                      "branchName":formobj.branchName,
                                      "address":formobj.branchaddress
                      }]
         }
    this.service.createCompany(data).subscribe(res=>{
      alert("Added Successfully.")
      setTimeout(() => {
        this.router.navigate(['/index']);
      }, 1000);
      this.getLatestDetails();
    })
  }

  getLatestDetails(){
    this.service.getAllCompany().subscribe(res=>{
      this.companydata=res;

      console.log(res)
  });
  
}

}
