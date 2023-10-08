import socket


def start_server():
    host = '127.0.0.1'  # Localhost
    port = 13000  # Port to bind to

    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((host, port))
    server_socket.listen(1)

    print(f"Server started at {host}:{port}")

    while True:
        print("Waiting for a connection...")
        client_socket, addr = server_socket.accept()
        print(f"Connection from {addr}")

        data = client_socket.recv(1024)
        if not data:
            print("No data received, closing connection")
            client_socket.close()
            continue

        print(f"Received data: {data.decode('utf-8')}")

        # Sending a response back to the client
        response = "Command Received"
        client_socket.send(response.encode('utf-8'))

        client_socket.close()


if __name__ == "__main__":
    start_server()
