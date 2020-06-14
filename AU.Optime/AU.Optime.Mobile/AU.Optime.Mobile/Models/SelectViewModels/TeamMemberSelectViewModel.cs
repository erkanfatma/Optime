using System;
using System.Collections.Generic;
using System.Text;

namespace AU.Optime.Mobile.Models.SelectViewModels {
      //Model for selecting user in the project members
      public class TeamMemberSelectViewModel {
            public int TeamMemberId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public bool IsSelected { get; set; }

            public TeamMemberSelectViewModel() {

            }

            public TeamMemberSelectViewModel(int teamMemberId, string fullName, bool isSelected) {
                  TeamMemberId = teamMemberId;
                  FullName = fullName;
                  IsSelected = isSelected;
            }
      }
}
