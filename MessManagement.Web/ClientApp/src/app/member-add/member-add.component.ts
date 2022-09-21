import { Component, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MemberService } from '../services/member.service';
import { Member } from '../Models/member';

export interface memberFormGroup {
  firstName: FormControl<string>;
  lastName?: FormControl<string | null>;
  mobileNumber: FormControl<string>;
  homeDistrict?: FormControl<string | null>;//? makes controls as optional
}
@Component({
  selector: 'app-member-add',
  templateUrl: './member-add.component.html',
  styleUrls: ['./member-add.component.css']
})


export class MemberAddComponent implements OnInit {

  member: Member = new Member();
  memberForm!: FormGroup<memberFormGroup>;

  constructor(
    public service: MemberService,
    public fb: FormBuilder,
    public dialogRef: MatDialogRef<MemberAddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      member: Member
    }
  ) {
    Object.assign(this.member, data.member);
  }
  ngOnInit(): void {
    this.dialogRef.updateSize('75%')
    this.createMemberForm();
    this.setValue();
  }
  createMemberForm() {
    this.memberForm = new FormGroup<memberFormGroup>({
      firstName: new FormControl<string>('', { nonNullable: true, validators: [Validators.required] }),
      lastName: new FormControl<string>('', { nonNullable: false }),
      mobileNumber: new FormControl<string>('', { nonNullable: true, validators: [Validators.required] }),
      homeDistrict: new FormControl<string>('')
    });
  }
  setValue() {
    if (this.member) {
      this.memberForm.patchValue({
        firstName: this.member.firstName,
        lastName: this.member.lastName,
        mobileNumber: this.member.mobileNumber,
        homeDistrict: this.member.homeDistrict
      })
    }
  }

  cancel() {
    this.dialogRef.close();
  }
  submit() {
    console.log(this.memberForm);
    this.member.firstName = this.memberForm.value.firstName as string;
    this.member.lastName = this.memberForm.value.lastName as string;
    this.member.mobileNumber = this.memberForm.value.mobileNumber as string;
    this.member.homeDistrict = this.memberForm.value.homeDistrict as string;

    if (this.member.id) {
      this.service.updateMember(this.member).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));

    } else {

      this.service.saveMember(this.member).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));


    }





  }
}