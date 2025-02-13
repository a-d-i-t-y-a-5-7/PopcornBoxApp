import { Component, Input } from '@angular/core';
import { Media } from 'src/app/models/media';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css'],
})
export class CardComponent {
  @Input() public item?: Media;
}
