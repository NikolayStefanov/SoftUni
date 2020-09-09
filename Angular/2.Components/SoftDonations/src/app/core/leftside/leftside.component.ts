import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ICause} from '../../shared/interfaces/cause';
import {CausesService } from '../../causes.service';



@Component({
  selector: 'app-leftside',
  templateUrl: './leftside.component.html',
  styleUrls: ['./leftside.component.scss']
})
export class LeftsideComponent implements OnInit {

  get causes(){ return this.causesService.causes};

  constructor(private causesService: CausesService) {
   }

  ngOnInit(): void {
    this.causesService.loadCauses();
  }

}
