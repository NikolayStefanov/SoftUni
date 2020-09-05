import { Component, OnInit, Input } from '@angular/core';
import {Article}from '../article.module';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  @Input() article: Article;
  
  visibleDescriptionLength = 0;
  imageIsShown = true;

  get hasMoreInfo(){
    return this.description.length >= this.visibleDescriptionLength;
  }

  get description(){
    return this.article.description.slice(0, this.visibleDescriptionLength)
  }

  constructor() { }

  toggleImage(){
    this.imageIsShown = !this.imageIsShown;
  }
  hideDesctiption(){
    this.visibleDescriptionLength = 0;
  }
  readMore(){
    if(this.description.length < this.visibleDescriptionLength){
      return;
    }
    this.visibleDescriptionLength += 250;
  }

  ngOnInit(): void {
  }

}
