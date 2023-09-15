from torchvision import transforms
from PIL import Image


def transform_image(image_path):
    transformation = transforms.Compose([
        transforms.Resize(256),
        transforms.CenterCrop(224),
        transforms.ToTensor(),
        transforms.Normalize(
            mean=[
                0.485, 0.456, 0.406
            ], 
            std=[
                0.229, 0.224, 0.225
            ]),
    ])

    image = Image.open(image_path)
    return transformation(image).unsqueeze(0)
