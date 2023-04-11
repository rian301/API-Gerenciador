using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class MentoredRepository : RepositoryBaseCRUD<Mentored, int>, IMentoredRepository
    {
        public MentoredRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public override async Task<List<Mentored>> GetAllAsync()
        {
            return await dbSet
                .Where(x => x.Deleted == DeletedEnum.No)
                .ToListAsync();
        }

        public Task<List<Mentored>> GetAllMentoredAndCompany()
        {
            return dbSet
                .Include(i => i.MentoredCompanies)
                .Include(i => i.Partners)
                .Where(x => x.Deleted == DeletedEnum.No)
                .ToListAsync();
        }
        public Task<List<Mentored>> GetAllByBirthdayMonth(string month)
        {
            return dbSet
                .Include(i => i.MentoredCompanies)
                .Include(i => i.Partners)
                .Where(x => x.BirthDate.Value.Month == int.Parse(month) && x.Deleted == DeletedEnum.No)
                .ToListAsync();
        }
        public Task<Mentored> GetMentoredAndCompany(int id)
        {
            return dbSet
                .Where(w => w.Id.Equals(id) && w.Deleted == DeletedEnum.No)
                .Include(i => i.Partners)
                .Include(i => i.MentoredCompanies)
                .FirstOrDefaultAsync();
        }

        public Task<GetMentoredAndPartnerQueryResult> GetMentoredAndPartner(int id)
        {
            return (from a in Context.Mentored
                    join b in Context.Partner on a.Id equals b.MentoredId into _b
                    from b in _b.DefaultIfEmpty()
                    select new GetMentoredAndPartnerQueryResult
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Email = a.Email,
                        BirthDate = a.BirthDate,
                        CPF = a.CPF,
                        RG = a.RG,
                        Country = a.Country,
                        State = a.State,
                        City = a.City,
                        District = a.District,
                        Street = a.Street,
                        Number = a.Number,
                        Complement = a.Complement,
                        ZipCode = a.ZipCode,
                        PhoneNumber = a.PhoneNumber,
                        Instagram = a.Instagram,
                        Note = a.Note,
                        PartnerId = b.MentoredPartnerId
                    })
                    .AsNoTracking()
                    .Where(x => x.Id == id && x.Deleted == DeletedEnum.No)
                    .FirstOrDefaultAsync();
        }

        public Task<List<Mentored>> GetAllMentoredAndCompaniesAsync(DateTime datInit, DateTime datEnd)
        {
            return dbSet
                .Where(x => x.CreatedAt.Date >= datInit.Date && x.CreatedAt.Date <= datEnd.Date)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<List<MentoredQueryResult>> GetAllMentoredAndCompaniesPaymentAsync(DateTime datInit, DateTime datEnd)
        {

            return null;
        }
    }
}
