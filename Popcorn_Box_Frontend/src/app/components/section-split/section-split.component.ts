import { Component, Input } from '@angular/core';
import { Section } from './section';

@Component({
  selector: 'app-section-split',
  templateUrl: './section-split.component.html',
  styleUrls: ['./section-split.component.scss']
})
export class SectionSplitComponent {
  @Input() public item: Section = new Section(); 
}
