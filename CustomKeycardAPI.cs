using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;

namespace CustomKeycardAPI
{

    public class CustomKeycardAPI : Plugin
    {
        public override string Name => "Custom Keycard API";

        public override string Description => "Allow players to custom their personal keycard.";

        public override string Author => "Kl1nge5";

        public override Version Version => new Version(0, 0, 1);

        public override Version RequiredApiVersion => new Version(LabApiProperties.CompiledVersion);

        public PluginEventHanders Events { get; } = new PluginEventHanders();

        public static Dictionary<string, PlayerKeycardProps> dtable;

        public override void Enable()
        {
            RefreshDataBase();
            CustomHandlersManager.RegisterEventsHandler(Events);
        }

        public override void Disable()
        {
            CustomHandlersManager.UnregisterEventsHandler(Events);
        }

        public static void RefreshDataBase()
        {
            LabApi.Features.Console.Logger.Info("CustomKeycard Refresh Database.");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 发起 GET 请求（同步）
                    HttpResponseMessage response = client.GetAsync("http://127.0.0.1:7778").Result;
                    response.EnsureSuccessStatusCode();

                    // 读取响应内容为字符串（同步）
                    string json = response.Content.ReadAsStringAsync().Result;

                    var options = new JsonSerializerOptions();
                    options.Converters.Add(new DTableConverter());
                    // 反序列化为对象
                    dtable = JsonSerializer.Deserialize<Dictionary<string, PlayerKeycardProps>>(json, options);

                    // 输出结果
                    foreach (var kvp in dtable)
                    {
                        LabApi.Features.Console.Logger.Info($"Key: {kvp.Key}, Value: {kvp.Value}");
                    }
                }
                catch (Exception ex)
                {
                    LabApi.Features.Console.Logger.Error($"发生错误: {ex.Message}");
                }
            }
        }
    }

    public class MTFKeycardProps
    {
        public string CardName { get; set; }
        public string HolderName { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }
        public string SeriesCode { get; set; }
    }

    public class MentalKeycardProps
    {
        public string CardName { get; set; }
        public string HolderName { get; set; }
        public string CardLabel { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }
        public Color LabelColor { get; set; }
        public string SeriesCode { get; set; }
    }

    public class Site02KeycardProps
    {
        public string CardName { get; set; }
        public string HolderName { get; set; }
        public string CardLabel { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }
        public Color LabelColor { get; set; }
    }

    public class ManagementKeycardProps
    {
        public string CardName { get; set; }
        public string CardLabel { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }
        public Color LabelColor { get; set; }
    }

    public class PlayerKeycardProps
    {
        public MTFKeycardProps KeycardMTFCaptain { get; set; }
        public MTFKeycardProps KeycardMTFOperative { get; set; }
        public MTFKeycardProps KeycardMTFPrivate { get; set; }
        public MentalKeycardProps KeycardGuard { get; set; }
        public Site02KeycardProps KeycardJanitor { get; set; }
        public Site02KeycardProps KeycardScientist { get; set; }
        public Site02KeycardProps KeycardResearchCoordinator { get; set; }
        public Site02KeycardProps KeycardContainmentEngineer { get; set; }
        public ManagementKeycardProps KeycardZoneManager { get; set; }
        public ManagementKeycardProps KeycardFacilityManager { get; set; }
    }

    public class DTableConverter : JsonConverter<Dictionary<string, PlayerKeycardProps>>
    {
        public override Dictionary<string, PlayerKeycardProps> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                Dictionary<string, PlayerKeycardProps> tmpTable = new Dictionary<string, PlayerKeycardProps>();

                var root = doc.RootElement;
                foreach (JsonProperty prop in root.EnumerateObject())
                {
                    string SteamID = prop.Name;
                    tmpTable[SteamID] = new PlayerKeycardProps();

                    JsonElement Object1 = prop.Value;
                    foreach (JsonProperty prop2 in Object1.EnumerateObject())
                    {
                        string CardType = prop2.Name;
                        JsonElement Object2 = prop2.Value;
                        switch (CardType)
                        {
                            case "KeycardMTFCaptain":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[2].EnumerateArray().ToList();
                                    var scolorl = list[3].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardMTFCaptain = new MTFKeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        HolderName = list[1].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        SeriesCode = list[4].GetString(),
                                    };
                                    break;
                                }
                            case "KeycardMTFOperative":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[2].EnumerateArray().ToList();
                                    var scolorl = list[3].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardMTFOperative = new MTFKeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        HolderName = list[1].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        SeriesCode = list[4].GetString(),
                                    }; break;
                                }
                            case "KeycardMTFPrivate":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[2].EnumerateArray().ToList();
                                    var scolorl = list[3].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardMTFPrivate = new MTFKeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        HolderName = list[1].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        SeriesCode = list[4].GetString(),
                                    }; break;
                                }
                            case "KeycardGuard":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[3].EnumerateArray().ToList();
                                    var scolorl = list[4].EnumerateArray().ToList();
                                    var lcolorl = list[5].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardGuard = new MentalKeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        HolderName = list[1].GetString(),
                                        CardLabel = list[2].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        LabelColor = new Color(lcolorl[0].GetSingle(), lcolorl[1].GetSingle(), lcolorl[2].GetSingle()),
                                        SeriesCode = list[6].GetString(),
                                    }; break;
                                }
                            case "KeycardJanitor":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[3].EnumerateArray().ToList();
                                    var scolorl = list[4].EnumerateArray().ToList();
                                    var lcolorl = list[5].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardJanitor = new Site02KeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        HolderName = list[1].GetString(),
                                        CardLabel = list[2].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        LabelColor = new Color(lcolorl[0].GetSingle(), lcolorl[1].GetSingle(), lcolorl[2].GetSingle()),
                                    }; break;
                                }
                            case "KeycardScientist":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[3].EnumerateArray().ToList();
                                    var scolorl = list[4].EnumerateArray().ToList();
                                    var lcolorl = list[5].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardScientist = new Site02KeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        HolderName = list[1].GetString(),
                                        CardLabel = list[2].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        LabelColor = new Color(lcolorl[0].GetSingle(), lcolorl[1].GetSingle(), lcolorl[2].GetSingle()),
                                    }; break;
                                }
                            case "KeycardResearchCoordinator":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[3].EnumerateArray().ToList();
                                    var scolorl = list[4].EnumerateArray().ToList();
                                    var lcolorl = list[5].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardResearchCoordinator = new Site02KeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        HolderName = list[1].GetString(),
                                        CardLabel = list[2].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        LabelColor = new Color(lcolorl[0].GetSingle(), lcolorl[1].GetSingle(), lcolorl[2].GetSingle()),
                                    }; break;
                                }
                            case "KeycardContainmentEngineer":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[3].EnumerateArray().ToList();
                                    var scolorl = list[4].EnumerateArray().ToList();
                                    var lcolorl = list[5].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardContainmentEngineer = new Site02KeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        HolderName = list[1].GetString(),
                                        CardLabel = list[2].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        LabelColor = new Color(lcolorl[0].GetSingle(), lcolorl[1].GetSingle(), lcolorl[2].GetSingle()),
                                    }; break;
                                }
                            case "KeycardZoneManager":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[2].EnumerateArray().ToList();
                                    var scolorl = list[3].EnumerateArray().ToList();
                                    var lcolorl = list[4].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardZoneManager = new ManagementKeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        CardLabel = list[1].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        LabelColor = new Color(lcolorl[0].GetSingle(), lcolorl[1].GetSingle(), lcolorl[2].GetSingle()),
                                    }; break;
                                }
                            case "KeycardFacilityManager":
                                {
                                    var list = Object2.EnumerateArray().ToList();
                                    var pcolorl = list[2].EnumerateArray().ToList();
                                    var scolorl = list[3].EnumerateArray().ToList();
                                    var lcolorl = list[4].EnumerateArray().ToList();
                                    tmpTable[SteamID].KeycardFacilityManager = new ManagementKeycardProps
                                    {
                                        CardName = list[0].GetString(),
                                        CardLabel = list[1].GetString(),
                                        PrimaryColor = new Color(pcolorl[0].GetSingle(), pcolorl[1].GetSingle(), pcolorl[2].GetSingle()),
                                        SecondaryColor = new Color(scolorl[0].GetSingle(), scolorl[1].GetSingle(), scolorl[2].GetSingle()),
                                        LabelColor = new Color(lcolorl[0].GetSingle(), lcolorl[1].GetSingle(), lcolorl[2].GetSingle()),
                                    }; break;
                                }
                        }
                    }
                }

                return tmpTable;
            }
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<string, PlayerKeycardProps> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
