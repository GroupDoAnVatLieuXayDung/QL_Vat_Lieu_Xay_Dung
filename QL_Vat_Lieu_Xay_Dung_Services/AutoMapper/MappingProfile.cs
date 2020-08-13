using AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Common;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.User;

namespace QL_Vat_Lieu_Xay_Dung_Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Domain To ViewModel

            CreateMap<ProductCategory, ProductCategoryViewModel>();

            CreateMap<Product, ProductViewModel>();

            CreateMap<AppUser, AppUserViewModel>();

            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<Permission, PermissionViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Bill, BillViewModel>();
            CreateMap<BillDetail, BillDetailViewModel>();
            CreateMap<Size, SizeViewModel>();
            CreateMap<ProductImage, ProductImageViewModel>();
            CreateMap<Slide, SlideViewModel>();

            CreateMap<Brand, BrandViewModel>();
            CreateMap<ProductReceipt, ProductReceiptViewModel>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<ProductReceiptDetail, ProductReceiptDetailViewModel>();

            CreateMap<Feedback, FeedbackViewModel>();
            CreateMap<Contact, ContactViewModel>();

            CreateMap<ProductTag, ProductTagViewModel>();
            CreateMap<Announcement, AnnouncementViewModel>();
            CreateMap<AnnouncementUser, AnnouncementUserViewModel>();

            #endregion Domain To ViewModel

            #region ViewModel To Domain

            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c.Name, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag,
                    c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<ProductViewModel, Product>()
                .ConstructUsing(c => new Product(c.Id, c.Name, c.CategoryId, c.Image, c.Price,
                    c.PromotionPrice, c.Description, c.BrandId, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Unit, c.Status,
                    c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));
            CreateMap<AppUserViewModel, AppUser>();
            CreateMap<TagViewModel, Tag>();
            CreateMap<AppRoleViewModel, AppRole>();

            CreateMap<FunctionViewModel, Function>();
            CreateMap<SizeViewModel, Size>();
            CreateMap<PermissionViewModel, Permission>()
                .ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete));
            CreateMap<BillViewModel, Bill>();
            CreateMap<BillDetailViewModel, BillDetail>();
            CreateMap<ProductImageViewModel, ProductImage>();
            CreateMap<SlideViewModel, Slide>().ConstructUsing(c => new Slide(c.Id, c.Name, c.Image, c.Url, c.DisplayOrder, c.Status, c.GroupAlias));
            CreateMap<BrandViewModel, Brand>();
            CreateMap<ProductReceiptViewModel, ProductReceipt>();
            CreateMap<ProductReceiptDetailViewModel, ProductReceiptDetail>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<ProductTagViewModel, ProductTag>();
            CreateMap<FeedbackViewModel, Feedback>();
            CreateMap<ContactViewModel, Contact>();

            CreateMap<AnnouncementViewModel, Announcement>()
                .ConstructUsing(c => new Announcement(c.Title, c.Content, c.Image, c.UserId, c.Status));

            CreateMap<AnnouncementUserViewModel, AnnouncementUser>()
                .ConstructUsing(c => new AnnouncementUser(c.AnnouncementId, c.UserId, c.HasRead));

            #endregion ViewModel To Domain
        }
    }
}