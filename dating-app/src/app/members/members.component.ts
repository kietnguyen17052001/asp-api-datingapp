import { Component, OnInit } from '@angular/core';
import { Member } from '../models/member';
import { MemberService } from '../_services/member.service';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  members: Member[] = [];
  constructor(public memberService: MemberService) { }

  ngOnInit(): void {
    this.memberService.getMembers().subscribe((members) => {
      this.members = members
    });
  }

}
