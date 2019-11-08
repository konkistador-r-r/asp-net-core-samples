using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TasksTrackerBLL.Model
{
    public class JobTask
    {
        public Guid Id { get; set; }
        [StringLength(512)]
        public string Subject { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid ResponsibleUserId { get; set; }
        public Guid? ResponsibleOrganizationId { get; set; }
        public string Description { get; set; }
        public bool Urgent { get; set; }
        public bool Done { get; set; }
        public bool Supervised { get; set; }
    }

    public class JobTaskDetails : JobTask, IUseAttachments<JobAttachment>
    {
        public User CreatedByUser { get; set; }
        public User ResponsibleUser { get; set; }
        public bool HasAttachments { get; set; }
        public List<JobAttachment> Attachments { get; set; }
        // put there othe references
    }

    public class JobTaskControl : JobTask
    {        
        public SuperviseResult SuperviseResult { get; set; } = SuperviseResult.Default;
    }

    public interface IUseAttachments<T> {
        bool HasAttachments { get; set; }
        List<T> Attachments { get; set; }
    }

    public class JobAttachment {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class User {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }

    public class UserDetails : User
    {
        public Organization Organization { get; set; }
    }

    public class Organization {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public enum SuperviseResult {
        Default,
        BigThumb,
        CoffeeCake,
        UnHappy
    }

    public class JobTaskFilter
    {
        public Guid? CreatedByUserId { get; set; }
        public Guid? ResponsibleUserId { get; set; }
        public Guid? ResponsibleOrganizationId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class ListPagingOptions
    {
        public int PageNumber { get; set; }
        public int PagesCount { get; set; }
    }
}
