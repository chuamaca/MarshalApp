using MarshalApp.Net.Rest.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarshalApp.Net.Rest.Infrastructure.Data.Contexts
{
    public partial class LibraryContext : DbContext
    {
        public void EnsureSeedDataForContext()
        {
            Database.Migrate();

            Authors.RemoveRange(Authors);
            Students.RemoveRange(Students);
            SaveChanges();

            List<Author> authors = new List<Author>()
            {
                new Author()
                {
                    AuthorId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    FirstName = "Stephen",
                    LastName = "King",
                    Genre = "Horror",
                    DateOfBirth = new DateTimeOffset(new DateTime(1947, 9, 21)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                            Title = "The Shining",
                            Description = "The Shining is a horror novel by American author Stephen King. Published in 1977, it is King's third published novel and first hardback bestseller: the success of the book firmly established King as a preeminent author in the horror genre. "
                        },
                        new Book()
                        {
                            BookId = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                            Title = "Misery",
                            Description = "Misery is a 1987 psychological horror novel by Stephen King. This novel was nominated for the World Fantasy Award for Best Novel in 1988, and was later made into a Hollywood film and an off-Broadway play of the same name."
                        },
                        new Book()
                        {
                            BookId = new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                            Title = "It",
                            Description = "It is a 1986 horror novel by American author Stephen King. The story follows the exploits of seven children as they are terrorized by the eponymous being, which exploits the fears and phobias of its victims in order to disguise itself while hunting its prey. 'It' primarily appears in the form of a clown in order to attract its preferred prey of young children."
                        },
                        new Book()
                         {
                             BookId = new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                             Title = "The Stand",
                             Description = "The Stand is a post-apocalyptic horror/fantasy novel by American author Stephen King. It expands upon the scenario of his earlier short story 'Night Surf' and outlines the total breakdown of society after the accidental release of a strain of influenza that had been modified for biological warfare causes an apocalyptic pandemic which kills off the majority of the world's human population."
                         }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    FirstName = "George",
                    LastName = "RR Martin",
                    Genre = "Fantasy",
                    DateOfBirth = new DateTimeOffset(new DateTime(1948, 9, 20)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                            Title = "A Game of Thrones",
                            Description = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin. It was first published on August 1, 1996."
                        },
                        new Book()
                        {
                            BookId = new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                            Title = "The Winds of Winter",
                            Description = "Forthcoming 6th novel in A Song of Ice and Fire."
                        },
                        new Book()
                        {
                            BookId = new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                            Title = "A Dance with Dragons",
                            Description = "A Dance with Dragons is the fifth of seven planned novels in the epic fantasy series A Song of Ice and Fire by American author George R. R. Martin."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                    FirstName = "Neil",
                    LastName = "Gaiman",
                    Genre = "Fantasy",
                    DateOfBirth = new DateTimeOffset(new DateTime(1960, 11, 10)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                            Title = "American Gods",
                            Description = "American Gods is a Hugo and Nebula Award-winning novel by English author Neil Gaiman. The novel is a blend of Americana, fantasy, and various strands of ancient and modern mythology, all centering on the mysterious and taciturn Shadow."
                        }
                    }
                },
                new Author()
                {
                    AuthorId= new Guid("578359b7-1967-41d6-8b87-64ab7605587e"),
                    FirstName = "Tom",
                    LastName = "Lanoye",
                    Genre = "Various",
                    DateOfBirth = new DateTimeOffset(new DateTime(1958, 8, 27)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                            Title = "Speechless",
                            Description = "Good-natured and often humorous, Speechless is at times a 'song of curses', as Lanoye describes the conflicts with his beloved diva of a mother and her brave struggle with decline and death."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"),
                    FirstName = "Douglas",
                    LastName = "Adams",
                    Genre = "Science fiction",
                    DateOfBirth = new DateTimeOffset(new DateTime(1952, 3, 11)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                            Title = "The Hitchhiker's Guide to the Galaxy",
                            Description = "The Hitchhiker's Guide to the Galaxy is the first of five books in the Hitchhiker's Guide to the Galaxy comedy science fiction 'trilogy' by Douglas Adams."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("a1da1d8e-1988-4634-b538-a01709477b77"),
                    FirstName = "Jens",
                    LastName = "Lapidus",
                    Genre = "Thriller",
                    DateOfBirth = new DateTimeOffset(new DateTime(1974, 5, 24)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                            Title = "Easy Money",
                            Description = "Easy Money or Snabba cash is a novel from 2006 by Jens Lapidus. It has been a success in term of sales, and the paperback was the fourth best seller of Swedish novels in 2007."
                        }
                    }
                },

            };
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    StudentId = new Guid("d1873677-b1a8-41ba-ab75-3b8b182a40e6"),
                    FirstName = "Cesar Huamani",
                    LastName = "Castro",
                    Phone="914124976",
                    Birthdate = new DateTimeOffset(new DateTime(1997,2,07)),
                    Gender  = "Masculino",
                    Collegecareer="Sistemas",
                    Grades = new List<Grade>()
                    {
                        new Grade()
                        {
                            GradeId= new Guid("a3079599-4a0d-4753-bdf6-ce7b5b7cd3f4"),
                            Subject= "PHP",
                            Qualification=18,
                            Description="Curso de PHP Basico",
                            StartDate = new DateTimeOffset(new DateTime(2022, 5,20)),
                            Status= "Activo"
                        },new Grade()
                        {
                            GradeId= new Guid("749371dd-e877-43a0-9965-65653b8b1f60"),
                            Subject= ".NET CORE 6",
                            Qualification=18,
                            Description="Curso de .NET Core Basico",
                            StartDate = new DateTimeOffset(new DateTime(2022, 5,20)),
                            Status= "Activo"
                        }
                    }
                },
                 new Student()
                {
                    StudentId = new Guid("1f26e78c-20e6-4ea8-b6df-6c3d4a8bc457"),
                    FirstName = "Fredi Lopez",
                    LastName = "Castro",
                    Phone="914124976",
                    Birthdate = new DateTimeOffset(new DateTime(1997,2,07)),
                    Gender  = "Masculino",
                    Collegecareer="Ing Civil",
                    Grades = new List<Grade>()
                    {
                        new Grade()
                        {
                            GradeId= new Guid("b1f4aa9b-9823-4b24-a0c2-053af196a619"),
                            Subject= "Autocat",
                            Qualification=18,
                            Description="Curso de Autocat Basico",
                            StartDate = new DateTimeOffset(new DateTime(2022, 5,20)),
                            Status= "Activo"
                        },new Grade()
                        {
                            GradeId= new Guid("a73f07ec-ef04-433a-bdf5-1fba8d6e0b89"),
                            Subject= "Diseno De estructuras",
                            Qualification=18,
                            Description="Especializacion de Carrera",
                            StartDate = new DateTimeOffset(new DateTime(2022, 5,20)),
                            Status= "Activo"
                        }
                    }
                }


            };
            Students.AddRange(students);
            Authors.AddRange(authors);
            SaveChanges();
        }
    }
}
