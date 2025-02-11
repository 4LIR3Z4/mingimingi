using LanguageLearning.Core.Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearning.Core.Application.Common.Abstractions;
public interface IDbContext
{
    //public DbSet<old_Member> User { get; set; }
    //public DbSet<Role> Role { get; set; }
    //public DbSet<PolicyType> Policy { get; set; }
    //public DbSet<Menu> Menu { get; set; }
    //public DbSet<UserMenuAccess> UserMenuAccess { get; set; }
    //public DbSet<Customer> Customer { get; set; }
    //public DbSet<old_CustomerMember> CustomerUser { get; set; }
    //public DbSet<Branch> Branch { get; set; }
    //public DbSet<GuarantorPolicyType> GuarantorPolicyType { get; set; }
    //public DbSet<LoanRequest> LoanRequest { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Agreement> Agreement { get; set; }
    //public DbSet<AgreementRegistrarUsers> AgreementUser { get; set; }
    //public DbSet<AgreementRegistrarBranches> AgreementBranch { get; set; }
    //public DbSet<AgreementAgentBranch> Agreement_AgentBranch { get; set; }
    //public DbSet<AgreementPolicies> AgreementPolicies { get; set; }


    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
