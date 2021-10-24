using AutoMapper;
using FluentAssertions;
using Imagegram.Application.Contracts.Persistence;
using Imagegram.Application.Interfaces;
using Imagegram.Application.Profiles;
using Imagegram.Application.Services;
using Imagegram.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Imagegram.UnitTests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetAll_ShouldReturnAllUsers()
        {
            const int TOTAL_USER_COUNT = 3;
            var mockUserRepo = new Mock<IImgramUserRepository>();
            mockUserRepo.Setup(_ => _.GetAll()).ReturnsAsync(CreateFakeImgramUsers());

            var userService = CreateDefaultUserService(mockUserRepo.Object, CreateDefaultMapper());
            var results = await userService.GetAll();

            results.Should().HaveCount(TOTAL_USER_COUNT, "Because method should return all available data. In our case, its 3.");
        }

        private IUserService CreateDefaultUserService(IImgramUserRepository userRepository, IMapper mapper)
        {
            return new UserService(userRepository, mapper);
        }

        private IMapper CreateDefaultMapper()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            return mapperConfig.CreateMapper();
        }
        private List<ImgramUser> CreateFakeImgramUsers()
        {
            return new List<ImgramUser> {
                new ImgramUser {
                    Id = 1,
                    FirstName = "Jehonie",
                    MiddleName = "Nonie",
                    LastName = "Kun",
                    Username = "userno1",
                    DateCreated = new DateTime(2021, 10, 21, 11, 17, 45)
                },
                new ImgramUser {
                    Id = 2,
                    FirstName = "Haruman",
                    MiddleName = "Smith",
                    LastName = "Sonian",
                    Username = "simithinso",
                    DateCreated = new DateTime(2021, 10, 21, 12, 17, 45)
                },
                new ImgramUser {
                    Id = 3,
                    FirstName = "Lebron",
                    MiddleName = "Boy",
                    LastName = "Jameson",
                    Username = "thekingishere06",
                    DateCreated = new DateTime(2021, 10, 22, 3, 17, 45)
                }
            };
        }
    }
}
