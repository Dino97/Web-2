import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/services/admin/admin.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-new-admin',
  templateUrl: './new-admin.component.html',
  styleUrls: ['./new-admin.component.css']
})
export class NewAdminComponent implements OnInit {
  imageUrl: string = "/assets/images/noLogo.png";
  file2Upload: File = null;
  reader: FileReader;
  image;

  constructor(public service: AdminService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

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

  onSubmit(){
    this.service.addAdmin(this.image).subscribe(
      (res:any) => {
        if(res.succeeded){
          this.service.formModel.reset();
          this.toastr.success('New admin created.', 'Registration successful!');
        }else{
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username is already taken.', 'Registration failed!');
                break;
              default:
                this.toastr.error(element.description, 'Registration failed!');
                break;
            }
          });
        }
      },
      err => console.log(err)
    );
  }

}
