using AutoMapper;
using Moq;
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Services;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using Xunit;

namespace ApiSitea.Tests
{
    public class MedicamentoServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMedicamentoRepository> _repoMock;

        public MedicamentoServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
                cfg.CreateMap<MedicamentoCreateDto, Medicamento>();
                cfg.CreateMap<MedicamentoUpdateDto, Medicamento>();
            });
            _mapper = config.CreateMapper();
            _repoMock = new Mock<IMedicamentoRepository>();
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedDto()
        {
            // Arrange
            var createDto = new MedicamentoCreateDto { Nombre = "Paracetamol" };
            _repoMock.Setup(r => r.AddAsync(It.IsAny<Medicamento>()))
                     .ReturnsAsync((Medicamento m) => m);

            var service = new MedicamentoService(_repoMock.Object, _mapper);

            // Act
            var result = await service.CreateAsync(createDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Paracetamol", result.Nombre);
            _repoMock.Verify(r => r.AddAsync(It.IsAny<Medicamento>()), Times.Once);
        }
    }
}
