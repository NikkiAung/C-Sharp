using System;
using DataBase.Models;
using Domain.Models;

namespace Domain.Features;

public class BlogService
{
    private readonly AppDbContext _dbContext;

    public BlogService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ResponseModel GetBlogs()
    {
        try
        {
            var lst = _dbContext.TblBlogs.ToList();
            return new ResponseModel(true, "Success", lst);
        }
        catch (Exception ex)
        {
            return new ResponseModel(false, ex.ToString());
        }
    }

    public ResponseModel GetBlogs(int pageNo, int pageSize)
    {
        try
        {
            var blogs = _dbContext.TblBlogs
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new ResponseModel(true, "Success", blogs);
        }
        catch (Exception ex)
        {
            return new ResponseModel(false, ex.ToString());
        }
    }

    public ResponseModel GetBlog(int id)
    {
        try
        {
            var item = _dbContext.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return new ResponseModel(false, "Blog not found");
            }
            return new ResponseModel(true, "Success", item);
        }
        catch (Exception ex)
        {
            return new ResponseModel(false, ex.ToString());
        }
    }

    public ResponseModel CreateBlog(TblBlog blog)
    {
        try
        {
            if (blog == null)
            {
                return new ResponseModel(false, "Invalid blog data");
            }
            _dbContext.TblBlogs.Add(blog);
            _dbContext.SaveChanges();
            return new ResponseModel(true, "Blog created successfully");
        }
        catch (Exception ex)
        {
            return new ResponseModel(false, ex.ToString());
        }
    }
}
