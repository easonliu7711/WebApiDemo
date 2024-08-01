## Asp-Demo 開發環境安裝說明

### 本機開發環境需搭配使用相關第三方服務，採用Docker方式安裝，依照下列程序安裝

#### 本機有直接安裝docker
* 執行docker-compose啟動相關第三方服務
  ```bash
  cd .\asp-demo-docker ; docker-compose up -d
  ```

#### 使用WSL安裝docker
* 請先確認docker是否有啟動，如果沒有請執行下列指令啟動docker
  ```bash
   wsl sudo service docker start
  ```
* 執行docker-compose啟動相關第三方服務
  ```bash
   $path = wsl pwd ; $path = $path + "/asp-demo-docker/docker-compose.yml" ; wsl docker-compose -f $path up -d
  ```

## 代辦事件

- [x] 基礎專案架構
- [x] 基礎專案配置
- [x] 開發環境 Docker-Compose
- [x] Controller & Service & Data
- [x] 數據庫遷移工具(Evolve)
- [x] DB CreateTime & UpdateTime 自動添加
- [x] 資料時區問題
- [x] Swagger
- [ ] Redis Cache機制
- [ ] Local Cache機制
- [ ] 數據加密
- [ ] Validation
- [ ] ExceptionHandler
- [ ] LogHandler
- [ ] ResponseHandler
- [x] HealthCheck
- [ ] OAuth2(Keycloak)
- [ ] CORS
- [ ] 單元測試和整合測試


  
