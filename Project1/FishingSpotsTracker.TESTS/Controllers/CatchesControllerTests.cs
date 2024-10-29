using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishingSpotsTracker.Controllers;
using FishingSpotsTracker.Data;
using FishingSpotsTracker.Models;
using FishingSpotsTracker.Mappers;
using FishingSpotsTracker.Dtos.FishCatch;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace FishingSpotsTracker.TESTS.Controllers
{    public class CatchesControllerTests
    {
        private readonly Mock<DbSet<FishCatch>> _mockCatchDbSet;
        private readonly Mock<ApplicationDBContext> _mockContext;

        public CatchesControllerTests()
        {
            _mockCatchDbSet = new Mock<DbSet<FishCatch>>();
            _mockContext = new Mock<ApplicationDBContext>(MockBehavior.Loose);
            _mockContext.Setup(c => c.FishCatches).Returns(_mockCatchDbSet.Object);
        }
    }

}

