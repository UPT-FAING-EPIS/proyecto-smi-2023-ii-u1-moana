from fastapi import FastAPI
from Api.routes import router  # Import your router from the module you've defined it in

app = FastAPI()

app.include_router(router)
