using Nate.DockerComposeUI.Domain.Model.Entities;

namespace Nate.DockerComposeUI.Domain.Model.Aggregates;

public class ImageAggregate
{
    private ImageEntity _imageEntity;
    
    public ImageAggregate(ImageEntity imageEntity)
    {
        _imageEntity = imageEntity;
    }


public ImageEntity ToEntity()
    {
        throw new NotImplementedException();
    }
}