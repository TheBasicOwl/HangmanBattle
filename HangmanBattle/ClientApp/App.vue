<template>
    <div class="test">
        <div class="container">
            <div class="row">&nbsp;</div>
            <div class="row">
                <div class="col-2">User</div>
                <div class="col-4">
                    <input v-model="user" type="text" id="userInput" />
                </div>
            </div>
            <div class="row">
                <div class="col-2">Message</div>
                <div class="col-4">
                    <input v-model="message" type="text" id="messageInput" />
                </div>
            </div>
            <div class="row">&nbsp;</div>
            <div class="row">
                <div class="col-6">
                    <input  @click="sendMesseage" type="button" id="sendButton" value="Send Message" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <ul id="messagesList">
                    <li v-for="msg in messages">{{msg}}</li>
                </ul>
            </div>
        </div>   
    </div>
</template>

<script>
    export default {
        data() {
            return {
                user : '',
                message : '',
                messages : []
            }
        },
        methods: {
           async sendMesseage() {
                console.log("A messeage has been sendt");   
                await this.$socket.invoke('SendMessage', this.user , this.message)
           }  
        },
        sockets: {
            ReceiveMessage(msg) {
                console.log(msg);
                this.messages.push(msg);
            }
        }
    };
</script>

<style>
</style>