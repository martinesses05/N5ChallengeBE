using Microsoft.EntityFrameworkCore;
using Moq;
using N5.Permissions.Core.DAL;
using N5.Permissions.Core.Entities;

namespace N5.Permissions.Tests.MockData
{
    public static class MockDataFactory
    {
        public static Mock<AppDBContext> GetDbContext()
        {
            var dbContextMock = new Mock<AppDBContext>();
            
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            var dbContext = new AppDBContext(options);

            
            var permissionTypes = new List<PermissionType>
            {
                new PermissionType { Id = 1, Description = "Type 1" },
                new PermissionType { Id = 2, Description = "Type 2" },
                new PermissionType { Id = 3, Description = "Type 3" }
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<PermissionType>>();
            dbSetMock.As<IQueryable<PermissionType>>().Setup(m => m.Provider).Returns(permissionTypes.Provider);
            dbSetMock.As<IQueryable<PermissionType>>().Setup(m => m.Expression).Returns(permissionTypes.Expression);
            dbSetMock.As<IQueryable<PermissionType>>().Setup(m => m.ElementType).Returns(permissionTypes.ElementType);
            dbSetMock.As<IQueryable<PermissionType>>().Setup(m => m.GetEnumerator()).Returns(permissionTypes.GetEnumerator());
            
            dbContextMock.Setup(x => x.PermissionTypes).Returns(dbSetMock.Object);

            return dbContextMock;
        }
    }
}
