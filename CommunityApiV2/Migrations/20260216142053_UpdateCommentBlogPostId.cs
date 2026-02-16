using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityApiV2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentBlogPostId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "BlogPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogPostId",
                table: "Comments",
                newName: "PostId");
        }
    }
}
