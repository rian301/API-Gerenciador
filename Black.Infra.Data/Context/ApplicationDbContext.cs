using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.CrossCutting.Identity;
using Black.Infra.CrossCutting.Identity.Models;
using System.Linq;
using Black.Infra.Data.Extensions;
using Black.Infra.Data.Map;
using Procard.Domain.Models;

namespace Black.Infra.Data.Context
{
    public class ApplicationDbContext : AuditableDbContext
    {
        #region Constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUser user) : base(options, user)
        {
        }
        #endregion                
        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Launch> Launch { get; set; }
        public DbSet<CustomerLaunch> CustomerLaunch { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CustomerProduct> CustomerProduct { get; set; }
        public DbSet<Award> Award { get; set; }
        public DbSet<CustomerAward> CustomerAward { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<CustomerPayment> CustomerPayment { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ExpenseControl> ExpenseControl { get; set; }
        public DbSet<Mentored> Mentored { get; set; }
        public DbSet<MentoredAward> MentoredAward { get; set; }
        public DbSet<MentoredCompany> MentoredCompany { get; set; }
        public DbSet<MentoredDoc> MentoredDoc { get; set; }
        public DbSet<MentoredPayment> MentoredPayment { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ExpenseControlDoc> ExpenseControlDoc { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<DailyPayment> DailyPayment { get; set; }
        public DbSet<DailyPaymentDoc> DailyPaymentDoc { get; set; }
        public DbSet<EmployeeDoc> EmployeeDoc { get; set; }
        public DbSet<AssetsCategory> AssetsCategory { get; set; }
        public DbSet<Patrimony> Patrimony { get; set; }
        public DbSet<PatrimonyDoc> PatrimonyDoc { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<PurchaseControl> PurchaseControl { get; set; }
        public DbSet<PurchaseControlDoc> PurchaseControlDoc { get; set; }
        public DbSet<Pendency> Pendency { get; set; }
        public DbSet<PendencyDoc> PendencyDoc { get; set; }
        public DbSet<Sent> Sent { get; set; }
        public DbSet<App> App { get; set; }
        public DbSet<Gift> Gift { get; set; }
        public DbSet<GiftDoc> GiftDoc { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserProfilePermission> UserProfilePermission { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<LoginRefreshToken> LoginRefreshToken { get; set; }
        public DbSet<LogErro> LogErro { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<ValidationFailure>();
            builder.Ignore<ValidationResult>();

            builder.AddConfiguration(new UserMap());
            builder.AddConfiguration(new CustomerMap());
            builder.AddConfiguration(new LaunchMap());
            builder.AddConfiguration(new CustomerLaunchMap());
            builder.AddConfiguration(new ProductMap());
            builder.AddConfiguration(new CustomerProductMap());
            builder.AddConfiguration(new AwardMap());
            builder.AddConfiguration(new LaunchMap());
            builder.AddConfiguration(new CustomerAwardMap());
            builder.AddConfiguration(new PaymentMethodMap());
            builder.AddConfiguration(new CustomerPaymentMap());
            builder.AddConfiguration(new ClassMap());
            builder.AddConfiguration(new ExpenseControlMap());
            builder.AddConfiguration(new MentoredMap());
            builder.AddConfiguration(new MentoredAwardMap());
            builder.AddConfiguration(new MentoredCompanyMap());
            builder.AddConfiguration(new MentoredDocMap());
            builder.AddConfiguration(new MentoredPaymentMap());
            builder.AddConfiguration(new InvoiceMap());
            builder.AddConfiguration(new SubscriptionMap());
            builder.AddConfiguration(new EmployeeMap());
            builder.AddConfiguration(new ExpenseControlDocMap());
            builder.AddConfiguration(new ProviderMap());
            builder.AddConfiguration(new ExpenseCategoryMap());
            builder.AddConfiguration(new PartnerMap());
            builder.AddConfiguration(new DailyPaymentMap());
            builder.AddConfiguration(new DailyPaymentDocMap());
            builder.AddConfiguration(new EmployeeDocMap());
            builder.AddConfiguration(new AssetsCategoryMap());
            builder.AddConfiguration(new PatrimonyMap());
            builder.AddConfiguration(new PatrimonyDocMap());
            builder.AddConfiguration(new DocumentMap());
            builder.AddConfiguration(new PurchaseControlMap());
            builder.AddConfiguration(new PurchaseControlDocMap());
            builder.AddConfiguration(new PendencyMap());
            builder.AddConfiguration(new PendencyDocMap());
            builder.AddConfiguration(new SentMap());
            builder.AddConfiguration(new AppMap());
            builder.AddConfiguration(new GiftMap());
            builder.AddConfiguration(new GiftDocMap());

            builder.AddConfiguration(new UserProfileMap());
            builder.AddConfiguration(new UserProfilePermissionMap());
            builder.AddConfiguration(new PermissionMap());

            base.OnModelCreating(builder);

            builder.Entity<Role>(e => e.ToTable("Roles"));
            builder.Entity<RoleClaim>(e => e.ToTable("RoleClaim"));

            builder.Entity<User>(e => e.ToTable("User"));
            builder.Entity<UserClaim>(e => e.ToTable("UserClaim"));
            builder.Entity<UserLogin>(e => e.ToTable("UserLogin"));
            builder.Entity<UserToken>(e => e.ToTable("UserToken"));
            builder.Entity<UserRole>(e => e.ToTable("UserRole"));

            // Remove cascade mode
            var cascadeFKs = builder.Model.GetEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
