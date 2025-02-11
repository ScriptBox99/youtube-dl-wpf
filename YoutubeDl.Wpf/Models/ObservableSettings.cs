﻿using MaterialDesignThemes.Wpf;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace YoutubeDl.Wpf.Models;

public class ObservableSettings : ReactiveObject
{
    public BaseTheme AppColorMode { get; set; }

    [Reactive]
    public BackendTypes Backend { get; set; }

    [Reactive]
    public string BackendPath { get; set; }

    /// <summary>
    /// Gets or sets the list of arguments passed
    /// to the backend process for all types of operations.
    /// </summary>
    public ObservableCollection<BackendArgument> BackendGlobalArguments { get; set; }

    /// <summary>
    /// Gets or sets the list of arguments passed
    /// to the backend process for download operations.
    /// </summary>
    public List<BackendArgument> BackendDownloadArguments { get; set; }

    [Reactive]
    public bool BackendAutoUpdate { get; set; }

    [Reactive]
    public DateTimeOffset BackendLastUpdateCheck { get; set; }

    [Reactive]
    public string FfmpegPath { get; set; }

    [Reactive]
    public string Proxy { get; set; }

    [Reactive]
    public int LoggingMaxEntries { get; set; }

    [Reactive]
    public Preset? SelectedPreset { get; set; }

    /// <summary>
    /// This is a hack to prevent <see cref="SelectedPreset"/> from being changed to null.
    /// Another solution is to manually implement equality for <see cref="Preset"/>,
    /// which is much harder to get it right, and would look terrible compared to this little hack.
    /// </summary>
    [Reactive]
    public string SelectedPresetText { get; set; }

    public List<Preset> CustomPresets { get; set; }

    [Reactive]
    public bool AddMetadata { get; set; }

    [Reactive]
    public bool DownloadThumbnail { get; set; }

    [Reactive]
    public bool DownloadSubtitles { get; set; }

    [Reactive]
    public bool DownloadSubtitlesAllLanguages { get; set; }

    [Reactive]
    public bool DownloadAutoGeneratedSubtitles { get; set; }

    [Reactive]
    public bool DownloadPlaylist { get; set; }

    [Reactive]
    public bool UseCustomOutputTemplate { get; set; }

    [Reactive]
    public string CustomOutputTemplate { get; set; }

    [Reactive]
    public bool UseCustomPath { get; set; }

    [Reactive]
    public string DownloadPath { get; set; }

    /// <summary>
    /// Gets the list of download path history.
    /// New paths are always appended to the list.
    /// </summary>
    public List<string> DownloadPathHistory { get; set; }

    public ObservableSettings(Settings settings)
    {
        AppColorMode = settings.AppColorMode;
        Backend = settings.Backend;
        BackendPath = settings.BackendPath;
        BackendGlobalArguments = new(settings.BackendGlobalArguments);
        BackendDownloadArguments = new(settings.BackendDownloadArguments);
        BackendAutoUpdate = settings.BackendAutoUpdate;
        BackendLastUpdateCheck = settings.BackendLastUpdateCheck;
        FfmpegPath = settings.FfmpegPath;
        Proxy = settings.Proxy;
        LoggingMaxEntries = settings.LoggingMaxEntries;
        SelectedPreset = settings.SelectedPreset;
        SelectedPresetText = settings.SelectedPresetText;
        CustomPresets = new(settings.CustomPresets);
        AddMetadata = settings.AddMetadata;
        DownloadThumbnail = settings.DownloadThumbnail;
        DownloadSubtitles = settings.DownloadSubtitles;
        DownloadSubtitlesAllLanguages = settings.DownloadSubtitlesAllLanguages;
        DownloadAutoGeneratedSubtitles = settings.DownloadAutoGeneratedSubtitles;
        DownloadPlaylist = settings.DownloadPlaylist;
        UseCustomOutputTemplate = settings.UseCustomOutputTemplate;
        CustomOutputTemplate = settings.CustomOutputTemplate;
        UseCustomPath = settings.UseCustomPath;
        DownloadPath = settings.DownloadPath;
        DownloadPathHistory = new(settings.DownloadPathHistory);
    }

    public void UpdateSettings(Settings settings)
    {
        settings.AppColorMode = AppColorMode;
        settings.Backend = Backend;
        settings.BackendPath = BackendPath;
        settings.BackendGlobalArguments = BackendGlobalArguments.ToArray();
        settings.BackendDownloadArguments = BackendDownloadArguments.ToArray();
        settings.BackendAutoUpdate = BackendAutoUpdate;
        settings.BackendLastUpdateCheck = BackendLastUpdateCheck;
        settings.FfmpegPath = FfmpegPath;
        settings.Proxy = Proxy;
        settings.LoggingMaxEntries = LoggingMaxEntries;
        settings.SelectedPreset = SelectedPreset;
        settings.SelectedPresetText = SelectedPresetText;
        settings.CustomPresets = CustomPresets.ToArray();
        settings.AddMetadata = AddMetadata;
        settings.DownloadThumbnail = DownloadThumbnail;
        settings.DownloadSubtitles = DownloadSubtitles;
        settings.DownloadSubtitlesAllLanguages = DownloadSubtitlesAllLanguages;
        settings.DownloadAutoGeneratedSubtitles = DownloadAutoGeneratedSubtitles;
        settings.DownloadPlaylist = DownloadPlaylist;
        settings.UseCustomOutputTemplate = UseCustomOutputTemplate;
        settings.CustomOutputTemplate = CustomOutputTemplate;
        settings.UseCustomPath = UseCustomPath;
        settings.DownloadPath = DownloadPath;
        settings.DownloadPathHistory = DownloadPathHistory.ToArray();
    }
}
