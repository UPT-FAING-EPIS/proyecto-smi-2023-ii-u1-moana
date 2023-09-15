import os
import requests
from bs4 import BeautifulSoup

BASE_URL = "https://www.google.com/search?hl=en&tbm=isch&q="

CATEGORIES = [
    "Abrasions",
    "Bruises",
    "Burns",
    "Cut",
    "Ingrown_nails",
    "Laceration",
    "Stab_wound"
]

def fetch_images(query, num_images=20):
    url = BASE_URL + query.replace(' ', '+')
    response = requests.get(url)
    
    if response.status_code != 200:
        print(f"Failed to fetch images for query: {query}")
        return []

    soup = BeautifulSoup(response.content, 'html.parser')
    img_tags = soup.find_all('img')
    
    img_urls = []
    for img in img_tags:
        if not img.has_attr("src"):
            continue
        
        img_url = img["src"]
        
        if img_url.startswith("data:"):
            continue

        if not img_url.startswith(("http:", "https:")):
            img_url = "https://www.google.com" + img_url

        img_urls.append(img_url)

    return img_urls[:num_images]


def save_images(folder, urls):
    if not os.path.exists(folder):
        os.makedirs(folder)

    for i, url in enumerate(urls, start=1):
        response = requests.get(url)
        if response.status_code == 200:
            with open(os.path.join(folder, f"image_{i}.jpg"), 'wb') as f:
                f.write(response.content)

def main():
    for category in CATEGORIES:
        print(f"Fetching images for category: {category}")
        img_urls = fetch_images(category)
        save_images(os.path.join("Images", category), img_urls)

if __name__ == "__main__":
    main()
