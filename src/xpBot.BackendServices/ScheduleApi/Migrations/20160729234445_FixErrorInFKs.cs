using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleApi.Migrations
{
    public partial class FixErrorInFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Speakers_SessionId",
                table: "SessionSpeaker");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Sessions_SpeakerId",
                table: "SessionSpeaker");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Sessions_SessionId",
                table: "SessionSpeaker",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Speakers_SpeakerId",
                table: "SessionSpeaker",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Sessions_SessionId",
                table: "SessionSpeaker");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Speakers_SpeakerId",
                table: "SessionSpeaker");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Speakers_SessionId",
                table: "SessionSpeaker",
                column: "SessionId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Sessions_SpeakerId",
                table: "SessionSpeaker",
                column: "SpeakerId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
