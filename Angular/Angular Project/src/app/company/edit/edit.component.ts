import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WebapiService } from 'src/app/webapi.service';
import { Branch } from 'src/app/branch.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  companyobj: any;

  constructor(private service:WebapiService,private router:Router,private routers: ActivatedRoute) { }
  
 
  branch=new Branch();
  branchArray=[] as  any;

  ngOnInit(): void {
   
  const id=this.routers.snapshot.queryParamMap.get('id');
  this.service.getDetailsById(id).subscribe(data=>{
    
    this.companyobj=data;
    this.branchArray=this.companyobj.companyBranch;
  })
  }
  updateCompany()
{
 this.companyobj.totalBranch=this.branchArray.length;
  this.service.updateComapny(this.companyobj).subscribe(data=>{
    alert("Data Updated Successfully.")
    setTimeout(() => {
      this.router.navigate(['/index']).then(() => {
        window.location.reload();
      });
    }, 1000);
  })
}

AddMoreBranch()
{
  this.branch=new Branch();
  this.branchArray.push(this.branch);
}
removeBranchU(index:number){
this.branchArray.splice(index)
}



}
