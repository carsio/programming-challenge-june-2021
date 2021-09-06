FROM node:13-alpine as builder

WORKDIR /opt/app

COPY package*.json ./

RUN ls -la

RUN npm install

COPY . /opt/app

RUN npm run build

FROM nginx:1.17.1-alpine

RUN rm -rf /usr/share/nginx/html/*

COPY --from=builder /opt/app/build /usr/share/nginx/html

EXPOSE 80

CMD [ "nginx", "-g", "daemon off;" ]