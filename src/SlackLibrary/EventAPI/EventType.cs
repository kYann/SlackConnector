﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SlackLibrary.EventAPI
{
    public enum EventType
    {
		Unknown,
		app_mention,
		app_rate_limited,
		app_uninstalled,
		channel_archive,
		channel_created,
		channel_deleted,
		channel_history_changed,
		channel_rename,
		channel_unarchive,
		dnd_updated,
		dnd_updated_user,
		email_domain_changed,
		emoji_changed,
		file_change,
		file_comment_added,
		file_comment_deleted,
		file_comment_edited,
		file_created,
		file_deleted,
		file_public,
		file_shared,
		file_unshared,
		grid_migration_finished,
		grid_migration_started,
		group_archive,
		group_close,
		group_history_changed,
		group_open,
		group_rename,
		group_unarchive,
		im_close,
		im_created,
		im_history_changed,
		im_open,
		link_shared,
		member_joined_channel,
		member_left_channel,
		message,
		message_dot_channels,
		message_dot_groups,
		message_dot_im,
		message_dot_mpim,
		pin_added,
		pin_removed,
		reaction_added,
		reaction_removed,
		resources_added,
		resources_removed,
		scope_denied,
		scope_granted,
		star_added,
		star_removed,
		subteam_created,
		subteam_members_changed,
		subteam_self_added,
		subteam_self_removed,
		subteam_updated,
		team_domain_change,
		team_join,
		team_rename,
		tokens_revoked,
		url_verification,
		user_change
	}
}