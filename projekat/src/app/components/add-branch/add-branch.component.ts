import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';

@Component({
  selector: 'app-add-branch',
  templateUrl: './add-branch.component.html',
  styleUrls: ['./add-branch.component.css']
})
export class AddBranchComponent implements OnInit {

  constructor(public service: RentalAgencyService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit(){
    this.service.postBranch().subscribe(
      res => {
        this.service.getBranches().subscribe(
          resBranches => {
            this.service.getBranchUpdateEmitter().emit(resBranches)
        })
        this.toastr.success('New branch added.', 'Success!');
        this.service.formModel.reset();
      },
      err => {
        console.log(err);
      }
    )
  }
}
