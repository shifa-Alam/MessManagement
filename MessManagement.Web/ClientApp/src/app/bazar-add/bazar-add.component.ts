import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Bazar } from '../Models/bazar';
import { Member } from '../Models/member';
import { BazarService } from '../services/bazar.service';
export interface bazarFormGroup {
  memberId: FormControl<number>;
  amount: FormControl<number>;
  bazarDate: FormControl<any>;
}
@Component({
  selector: 'app-bazar-add',
  templateUrl: './bazar-add.component.html',
  styleUrls: ['./bazar-add.component.css']
})
export class BazarAddComponent implements OnInit {

  bazar: Bazar = new Bazar();
  bazarForm!: FormGroup<bazarFormGroup>;
  isLoading: boolean = false;
  members: Member[] = [];
  selectedMemberId: number = 0;
  constructor(
    public service: BazarService,
    public fb: FormBuilder,
    public dialogRef: MatDialogRef<BazarAddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      bazar: Bazar
    }
  ) {
    Object.assign(this.bazar, data.bazar);
  }
  ngOnInit(): void {
    this.getMembers();

    this.dialogRef.updateSize('75%')
    this.createBazarForm();
    this.setValue();

  }
  getMembers() {
    this.isLoading = true;
    this.service.getMembers().subscribe(result => {
      this.members = result;
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }
  createBazarForm() {
    this.bazarForm = new FormGroup<bazarFormGroup>({
      memberId: new FormControl<number>(0, { nonNullable: true, validators: [Validators.required] }),
      amount: new FormControl<number>(0, { nonNullable: true, validators: [Validators.required] }),
      bazarDate: new FormControl<Date>(new Date(),{ nonNullable: true, validators: [Validators.required] })
    });
  }
  setValue() {
    if (this.bazar) {
      this.bazarForm.patchValue({
        memberId: this.bazar.memberId,
        amount: this.bazar.amount,
        bazarDate: this.bazar.bazarDate as string
      })
    }
  }

  cancel() {
    this.dialogRef.close();
  }
  submit() {
    console.log(this.bazarForm);
    this.bazar.memberId = this.bazarForm.value.memberId as number;
    this.bazar.amount = this.bazarForm.value.amount as number;
    this.bazar.bazarDate = this.bazarForm.value.bazarDate;

    if (this.bazar.id) {
      this.service.updateBazar(this.bazar).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));

    } else {

      this.service.saveBazar(this.bazar).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));


    }





  }
}
