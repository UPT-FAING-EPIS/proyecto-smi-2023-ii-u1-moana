import os
import torch
import torch.nn as nn
import torch.optim as optim
from torchvision.models import ResNet50_Weights
from torchvision import datasets, transforms, models

DATA_DIR = r'D:\Proyectos\Universidad8\proyecto-smi-2023-ii-u1-moana\Images'
MODEL_PATH = 'model_wounds.pth'


def get_data_loaders(data_dir, batch_size):
    data_transforms = transforms.Compose([
        transforms.RandomResizedCrop(224),
        transforms.RandomHorizontalFlip(),
        transforms.ToTensor(),
        transforms.Normalize([0.485, 0.456, 0.406], [0.229, 0.224, 0.225])
    ])

    train_dataset = datasets.ImageFolder(data_dir, data_transforms)
    train_loader = torch.utils.data.DataLoader(train_dataset, batch_size=batch_size, shuffle=True, num_workers=4)

    return train_loader, len(train_dataset)


def get_model(num_classes, device):
    model = models.resnet50(weights=ResNet50_Weights.IMAGENET1K_V1)
    num_ftrs = model.fc.in_features
    model.fc = nn.Linear(num_ftrs, num_classes)
    return model.to(device)


def train_model(model, dataloaders, criterion, optimizer, dataset_sizes, device, num_epochs):
    for epoch in range(num_epochs):
        model.train()
        running_loss = 0.0
        running_corrects = 0

        for inputs, labels in dataloaders:
            inputs, labels = inputs.to(device), labels.to(device)
            optimizer.zero_grad()

            outputs = model(inputs)
            _, preds = torch.max(outputs, 1)
            loss = criterion(outputs, labels)
            loss.backward()
            optimizer.step()

            running_loss += loss.item() * inputs.size(0)
            running_corrects += torch.sum(preds == labels.data)

        epoch_loss = running_loss / dataset_sizes
        epoch_acc = running_corrects.double() / dataset_sizes

        print(f'Train Loss: {epoch_loss:.4f} Acc: {epoch_acc:.4f}')

    print('Entrenamiento completado!')


def save_trained_model(model, path):
    torch.save(model.state_dict(), path)
    print('Modelo guardado!')


def main():
    num_epochs = 10
    num_classes = 7
    batch_size = 16
    learning_rate = 0.001
    device = torch.device("cuda:0" if torch.cuda.is_available() else "cpu")

    dataloaders, dataset_sizes = get_data_loaders(DATA_DIR, batch_size)
    model = get_model(num_classes, device)
    criterion = nn.CrossEntropyLoss()
    optimizer = optim.Adam(model.parameters(), lr=learning_rate)

    train_model(model, dataloaders, criterion, optimizer, dataset_sizes, device, num_epochs)
    save_trained_model(model, MODEL_PATH)


if __name__ == '__main__':
    from multiprocessing import freeze_support
    freeze_support()
    main()
