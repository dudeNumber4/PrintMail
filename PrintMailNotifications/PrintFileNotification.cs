using MediatR;
using System;

namespace PrintMailDto
{
    public record PrintFileNotification(string fileName) : INotification
    {
        public FileName DTO => new FileName(fileName);
    }
}
