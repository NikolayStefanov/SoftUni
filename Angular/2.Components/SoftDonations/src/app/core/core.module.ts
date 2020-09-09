import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationComponent } from './navigation/navigation.component';
import { LeftsideComponent } from './leftside/leftside.component';
import { RightsideComponent } from './rightside/rightside.component';
import { FooterComponent } from './footer/footer.component';



@NgModule({
  declarations: [NavigationComponent, LeftsideComponent, RightsideComponent, FooterComponent],
  imports: [
    CommonModule
  ],
  exports: [NavigationComponent, LeftsideComponent,RightsideComponent, FooterComponent]
})
export class CoreModule { }
