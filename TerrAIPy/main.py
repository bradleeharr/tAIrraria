import socket
from runchat import *


def start_server():
    host = '127.0.0.1'  # Localhost
    port = 13000  # Port to bind to

    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((host, port))
    server_socket.listen(1)

    print(f"Server started at {host}:{port}")
    print("Waiting for a connection...")
    client_socket, addr = server_socket.accept()
    print(f"Connection from {addr}")
    return server_socket, client_socket


def receive_server(client_socket):
    data = client_socket.recv(1024)
    if not data:
        print("No data received, closing connection")
        client_socket.close()
    else:
        print(f"Received data: {data.decode('utf-8')}")
        # Sending a response back to the client
        response = "Data Received"
        client_socket.send(response.encode('utf-8'))
    return client_socket, data;


def close_server(client_socket):
    client_socket.close()


if __name__ == "__main__":
    messages = get_messages_and_api_key();
    server, client = start_server()
    while True:
        data = receive_server(client)
        chat_once(messages, data)

    close_server(client)
