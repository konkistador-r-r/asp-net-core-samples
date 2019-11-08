using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TasksTrackerBLL.Model;

namespace TasksTrackerBLL
{
    public class JobTaskBLL
    {
        public void GetAll(JobTaskFilter filter) {

        }

        public void GetPage(ListPagingOptions pageOptions, JobTaskFilter filter)
        {

        }
    }

    public interface IJobTaskDAL {

    }

    public class JobTaskDAL
    {
        public List<User> GetUsers(Guid organizationId) {
            return new List<User>{
                new User() {
                    Id = Guid.Parse("77BB9247-3F02-495F-8B36-7EB5991909D0"),
                    FullName = "User 1",
                    Phone = "123 123 123"
                }
            };
        }
        public List<JobTask> GetAllJobTask(JobTaskFilter filter = null)
        {
            var tasks = new List<JobTask>() {
                new JobTask {
                    Id = Guid.Parse("77230D39-135C-44CE-B847-A966814A7771"),
                    Subject = "Task 1 for User 2",
                    CreatedAt = new DateTime(2019, 11, 4, 12, 00, 00),
                    CreatedByUserId = Guid.Parse("77BB9247-3F02-495F-8B36-7EB5991909D0"), // User 1
                    ResponsibleUserId = Guid.Parse("77BB9247-3F02-495F-8B36-7EB5991909D1"), // User 2
                    ResponsibleOrganizationId = Guid.Parse("ADA6912D-36E2-433A-94B4-CB72414C48CA"), // Organization 1
                    Urgent = true,
                    Done = false,
                    Supervised = false
                },
                new JobTask {
                    Id = Guid.Parse("77230D39-135C-44CE-B847-A966814A7772"),
                    Subject = "Task 1 for User 3",
                    CreatedAt = new DateTime(2019, 11, 4, 13, 00, 00),
                    CreatedByUserId = Guid.Parse("77BB9247-3F02-495F-8B36-7EB5991909D0"), // User 1
                    ResponsibleUserId = Guid.Parse("77BB9247-3F02-495F-8B36-7EB5991909D2"), // User 3
                    ResponsibleOrganizationId = Guid.Parse("ADA6912D-36E2-433A-94B4-CB72414C48CA"), // Organization 1
                    Urgent = true,
                    Done = false,
                    Supervised = false
                },
                new JobTask {
                    Id = Guid.Parse("77230D39-135C-44CE-B847-A966814A7773"),
                    Subject = "Task 2 for User 3",
                    CreatedAt = new DateTime(2019, 11, 4, 14, 00, 00),
                    CreatedByUserId = Guid.Parse("77BB9247-3F02-495F-8B36-7EB5991909D0"), // User 1
                    ResponsibleUserId = Guid.Parse("77BB9247-3F02-495F-8B36-7EB5991909D2"), // User 3
                    ResponsibleOrganizationId = Guid.Parse("ADA6912D-36E2-433A-94B5-CB72414C48CA"), // Organization 2
                    Urgent = false,
                    Done = false,
                    Supervised = false
                }
            };
            var filteredTasks = tasks.AsQueryable();
            if (filter != null)
            {
                if (!filter.ResponsibleOrganizationId.HasValue)
                {
                    filteredTasks = filteredTasks.Where(t => t.ResponsibleOrganizationId.Equals(filter.ResponsibleOrganizationId.Value));
                }
                if (!filter.ResponsibleUserId.HasValue)
                {
                    filteredTasks = filteredTasks.Where(t => t.ResponsibleUserId.Equals(filter.ResponsibleUserId.Value));
                }
                if (!filter.ResponsibleUserId.HasValue)
                {
                    filteredTasks = filteredTasks.Where(t => t.CreatedByUserId.Equals(filter.CreatedByUserId.Value));
                }
                if (!filter.CreatedAt.HasValue)
                {
                    filteredTasks = filteredTasks.Where(t => t.CreatedAt.Date.Equals(filter.CreatedAt.Value.Date));
                }                
            }

            return filteredTasks.ToList();
        }

        public void GetPage(ListPagingOptions pageOptions, JobTaskFilter filter)
        {

        }
    }
}
