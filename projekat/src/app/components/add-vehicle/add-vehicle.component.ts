import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';
import { VehicleService } from 'src/app/services/vehicle/vehicle.service';

@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {
  imageUrl: string = "/assets/images/noImage.png";
  file2Upload: File = null;
  reader: FileReader;
  image;
  car;

  constructor(private dialogRef: MatDialogRef<AddVehicleComponent>, public service: VehicleService, private toastr: ToastrService,
    private branchService: RentalAgencyService) { }

  ngOnInit(): void { }

  handlerFileInput(file: FileList){
    this.file2Upload = file[0];

    let reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
      //this.service.formModel.value.CompanyLogo = reader.result
      this.image = reader.result;
    }
    reader.readAsDataURL(this.file2Upload);
  }

  onAdd(){
    this.service.addCar(this.image).subscribe(
      res => {
        this.toastr.success('New car added.', 'Success!');
        this.service.getCarUpdateEmitter().emit(res);
        this.branchService.getBranches().subscribe(
          result => {
            this.branchService.getBranchUpdateEmitter().emit(result)
          },
          error => console.log(error)
        )
      },
      err => console.log(err)
    )

    this.onClose()
  }

  onClose(){
    this.service.formModel.reset();
    this.image = "/assets/images/noImage.png";
    this.dialogRef.close();
  }
}
