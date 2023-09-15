import torch
import torch.nn.functional as F
from torchvision import models, transforms
from PIL import Image
import os

model_path = 'model_wounds.pth'
data_dir = 'D:\\Proyectos\\Universidad8\\proyecto-smi-2023-ii-u1-moana\\Images'
test_image_path = os.path.join(data_dir, 'test_image.jpg')
num_classes = 7

test_transforms = transforms.Compose([
    transforms.Resize(256),
    transforms.CenterCrop(224),
    transforms.ToTensor(),
    transforms.Normalize([0.485, 0.456, 0.406], [0.229, 0.224, 0.225])
])

def predict_image(image_path, model):
    image = Image.open(image_path)
    image_tensor = test_transforms(image).float()
    image_tensor = image_tensor.unsqueeze_(0)
    input_var = torch.autograd.Variable(image_tensor)
    input_var = input_var.to(device)
    output = model(input_var)
    _, predicted = torch.max(output.data, 1)
    return predicted.item()

device = torch.device("cuda:0" if torch.cuda.is_available() else "cpu")

model = models.resnet50(pretrained=False, num_classes=num_classes)
model.load_state_dict(torch.load(model_path))
model = model.to(device)
model.eval()

predicted_class = predict_image(test_image_path, model)
print(f"Clase Predicha: {predicted_class}")

classes = ['Abrasions', 'Bruises', 'Burns', 'Cut', 'Ingrown_nails', 'Laceration', 'Stab_wound']
print(f"Tipo de herida: {classes[predicted_class]}")
