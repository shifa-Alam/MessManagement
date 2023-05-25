import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Fund } from '../Models/fund';
import { Member } from '../Models/member';
import { FundService } from '../services/fund.service';
export interface fundFormGroup {
  memberId: FormControl<number>;
  purpose: FormControl<string>;
  amount: FormControl<number>;
  isDeduction: FormControl<boolean>;
  fundDate: FormControl<any>;
}
@Component({
  selector: 'app-fund-add',
  templateUrl: './fund-add.component.html',
  styleUrls: ['./fund-add.component.css']
})
export class FundAddComponent implements OnInit {

  fund: Fund = new Fund();
  fundForm!: FormGroup<fundFormGroup>;
  isLoading: boolean = false;
  members: Member[] = [];
  selectedMemberId: number = 0;
  constructor(
    public service: FundService,
    public fb: FormBuilder,
    public dialogRef: MatDialogRef<FundAddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      fund: Fund
    }
  ) {
    Object.assign(this.fund, data.fund);
  }
  ngOnInit(): void {
    this.getMembers();

    this.dialogRef.updateSize('75%')
    this.createFundForm();
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
  createFundForm() {
    this.fundForm = new FormGroup<fundFormGroup>({
      memberId: new FormControl<number>(0, { nonNullable: true, validators: [Validators.required] }),
      purpose: new FormControl<string>("", { nonNullable: true, validators: [Validators.required] }),
      amount: new FormControl<number>(0, { nonNullable: true, validators: [Validators.required] }),
      isDeduction: new FormControl<boolean>(false, { nonNullable: true, validators: [Validators.required] }),
      fundDate: new FormControl<Date>(new Date(), { nonNullable: true, validators: [Validators.required] })
    });
  }

  setValue() {
    if (this.fund) {
      this.fundForm.patchValue({
        memberId: this.fund.memberId,
        purpose: this.fund.purpose,
        amount: this.fund.amount,
        isDeduction: this.fund.isDeduction,
        fundDate: this.fund.fundDate

      })
    }
  }
  convert(str: string) {
    var date = new Date(str),
      mnth = ("0" + (date.getMonth() + 1)).slice(-2),
      day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join("-");
  }

  cancel() {
    this.dialogRef.close();
  }
  submit() {
    console.log(this.fundForm);

    this.fund.memberId = this.fundForm.value.memberId as number;
    this.fund.purpose = this.fundForm.value.purpose as string;
    this.fund.amount = this.fundForm.value.amount as number;
    this.fund.isDeduction = this.fundForm.value.isDeduction as boolean;
    this.fund.fundDate = this.fundForm.value.fundDate as Date;


    this.fund.fundDate = this.convert(this.fundForm.value.fundDate);
    console.log(this.fund);

    if (this.fund.id) {
      this.service.updateFund(this.fund).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));

    } else {

      this.service.saveFund(this.fund).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));


    }





  }
}
