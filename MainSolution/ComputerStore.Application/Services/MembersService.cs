using AutoMapper;
using ComputerStore.Application.Interfaces;
using ComputerStore.Application.ViewModels;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.Services
{
    public class MembersService : IMembersService
    {
        private IMembersRepository _repo;
        private IMapper _mapper;

        public MembersService(IMembersRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void AddMember(MemberViewModel m)
        {
            var newMember = _mapper.Map<MemberViewModel, Member>(m);
            _repo.AddMember(newMember);
        }
    }
}
