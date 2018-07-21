#
# Stage 0
# Build
FROM node:9.5.0-alpine as node
WORKDIR /app
COPY package.json yarn.lock /app/
RUN yarn
COPY ./ /app/
RUN yarn run build --prod

#
# Stage 1
# Final - based on Nginx, to have only the compiled app, ready for production with Nginx
FROM nginx:1.12.2-alpine
COPY --from=node /app/dist/ /usr/share/nginx
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
