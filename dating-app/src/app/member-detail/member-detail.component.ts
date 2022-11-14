import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Member } from '../models/member';
import { MemberService } from '../_services/member.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  @Input() member: Member | null = null;

  constructor(
    private memberService: MemberService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (!this.member) {
      const username = this.route.snapshot.params['id'];
      this.memberService.getMemberByUsername(username)
      .subscribe((member) => (this.member = member));
    }
  }

}
