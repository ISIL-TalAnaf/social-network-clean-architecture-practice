using AnafSocial.Application.DTOs;
using AnafSocial.Application.Interfaces;
using AnafSocial.Domain.Entities;
using AnafSocial.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AnafSocial.Application.Services;

public class PostService: IPostService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task CreateAsync(Guid userId, CreatePostDto dto)
    {
        var user = _unitOfWork.Users.GetByUserIdAsync(userId);
        if (user == null) {
            throw new Exception("User is null");
        }
        if (string.IsNullOrEmpty(dto.Content))
        {
            throw new Exception("The post content is empty");
        }
        
        


