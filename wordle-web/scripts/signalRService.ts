import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

export default class SignalRService {
  private url: string;
  private connection = ref<HubConnection | null>(null);
  public messages = ref<string[]>([]);

  constructor() {
    const baseUrl =
      window.location.hostname === "localhost" ||
      location.hostname === "127.0.0.1"
        ? "https://localhost:7266"
        : "https://wordleapiewu.azurewebsites.net";

    this.url = baseUrl + "/hub";
    this.startConnection();
    this.onReceiveMessage("ReceiveMessage", (message: string) => {
      console.log(message);
      console.log(this.messages.value);
      this.messages.value.push(message);
    });
  }

  private startConnection = async () => {
    this.connection.value = new HubConnectionBuilder()
      .withUrl(this.url)
      .build();

    this.connection.value.onclose((error: any) => {
      console.error("Connection Closed", error);
    });

    try {
      await this.connection.value.start();
      console.log("Connected!");
    } catch (error) {
      console.error("Connection Error: ", error);
    }
  };

  private onReceiveMessage = (
    methodName: string,
    callback: (...args: any[]) => void,
  ) => {
    this.connection.value?.on(methodName, callback);
  };

  public sendMessage(word: string) {
    if (this.connection.value) {
      this.connection.value.invoke("SendMessage", word);
    }
  }

  public stopConnection = async () => {
    if (!this.connection.value) return;
    await this.connection.value.stop();
    console.log("Disconnected!");
  };
}
