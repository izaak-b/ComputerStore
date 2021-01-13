using ComputerStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.Interfaces
{
    public interface IMembersService
    {
        void AddMember(MemberViewModel m);
    }
}
