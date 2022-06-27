using DoomMap_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using DoomMap_v2.UnitTests.Fixtures;
using Xunit;
using DoomMap_v2.Services;

namespace DoomMap_v2.UnitTests.Systems.Services
{
    public class TestFireService : IDisposable
    {
        protected readonly DoomMapContext _context;
        public TestFireService()
        {
            var options = new DbContextOptionsBuilder<DoomMapContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

            _context = new DoomMapContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllFiresAsync_ReturnFireCollection()
        {
            // arrange
            _context.CurrentFires.AddRange(FiresFixture.GetTestFires());
            _context.SaveChanges();

            var sut = new FiresService(_context);

            // act
            var result = await sut.GetAllFires();

            // assert
            result.Should().HaveCount(FiresFixture.GetTestFires().Count);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}

