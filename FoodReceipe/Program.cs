using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using Bussines.Abstract;
using Bussines.Concrete;
using Bussines.Validations;
using DataAcess.Abstract;
using DataAcess.Concrete;
using DataAcess.Context.SqlDbContext;
using Entities.Concrete.TableModels;
using FluentValidation;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//AppDbContext
builder.Services.AddDbContext<AppDbcontext>();

//Dependcy Injection DataAcces
builder.Services.AddScoped<IAboutDal, AboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IFoodDal, FoodDal>();
builder.Services.AddScoped<IFoodService,FoodManager>();
builder.Services.AddScoped<IMainDal, MainDal>();
builder.Services.AddScoped<IMainService, MainManager>();
builder.Services.AddScoped<IServiceDal, ServiceDal>();
builder.Services.AddScoped<IServiceManager,ServiceManager>();

builder.Services.AddScoped<IMainNewsLetterDal, MainNewsLetterDal>();
builder.Services.AddScoped<IMainNewsLetterService, MainNewsLetterManager>();
builder.Services.AddScoped<IAboutRightContentDal,AboutRightContentDal>();
builder.Services.AddScoped<IAboutRightContentService,AboutRightManager>();
builder.Services.AddScoped<IBlogDal, BlogDal>();
builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<ITestmonialDal, TestmonialDal>();
builder.Services.AddScoped<ITestmonialService, TestmonialManager>();
builder.Services.AddScoped<IMainCounterDal,MainCounterDal>();
builder.Services.AddScoped<IMainCounterService, MainCounterManager>();
builder.Services.AddScoped<IFoodCategoryDal, FoodCategoryDal>();
builder.Services.AddScoped<IFoodCategoryService, FoodCategoryManager>();



//Validation
builder.Services.AddScoped<IValidator<About>, AboutValidation>();
builder.Services.AddScoped<IValidator<Food>, FoodValidation>();
builder.Services.AddScoped<IValidator<Main>, MainValidation>();
builder.Services.AddScoped<IValidator<Service>, ServiceValidation>();

builder.Services.AddScoped<IValidator<MainNewsLetter>, MainNewsLetterValidation>();
builder.Services.AddScoped<IValidator<AboutRightContent>, AboutRightValidation>();
builder.Services.AddScoped<IValidator<BlogCard>, BlogValidation>();
builder.Services.AddScoped<IValidator<TestmonialSection>, TestmonialValidation>();

builder.Services.AddScoped<IValidator<MainCounter>, MainCounterValidation>();
builder.Services.AddScoped<IValidator<FoodCategory>, FoodCategoryValidation>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Areas",

        pattern: "{Area:exists}/{controller=Admin}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: default,
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
