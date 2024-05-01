using AutoMapper;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class Mapper :Profile
    {
        
            public Mapper(){
            CreateMap<User,UserReadDto>();
            CreateMap<UserReadDto,User>();
            CreateMap<UserReadDto,UserUpdateDto>();
            CreateMap<UserUpdateDto,UserReadDto>();
            CreateMap<User,UserUpdateDto>();
            CreateMap<UserUpdateDto,User>();
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductReadDto, Product>();

        }
    }
    }