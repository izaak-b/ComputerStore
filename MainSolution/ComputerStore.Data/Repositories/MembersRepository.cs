using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Data.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private ComputerStoreDbContext _context;

        public MembersRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public void AddMember(Member m)
        {
            _context.Members.Add(m);
            _context.SaveChanges();
        }
    }
}
