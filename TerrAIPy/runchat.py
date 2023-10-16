import openai
import os
import pandas as pd
import time

if __name__ == "__main__":
    openai.api_key = ""
    messages = [{"role": "system", "content": """You are a Terraria Playing Agent. Your health is 100/100. 
                                              You may execute code to move and interact with the game world.
                                              You are located in biome: Overworld.
                                              Continually ponder and aim to explore the world. """}]

    while True:
        message = input("User : ")
        if message:
            messages.append(
                {"role": "user", "content": message + "Write code to execute your intended Terraria game actions"},
            )
            chat = openai.ChatCompletion.create(
                model="gpt-3.5-turbo", messages=messages
            )

        reply = chat.choices[0].message.content
        print(f"ChatGPT: {reply}")
        messages.append({"role": "assistant", "content": reply})
        f = open("conversations.txt", "a")
        for message in messages:
            for key in message:
                f.write(message[key])
        f.close()